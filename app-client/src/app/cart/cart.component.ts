import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { take } from 'rxjs/operators';
import { ApiPaths } from '../enums/api-paths';
import { CartQuantity } from '../enums/card-quantity';
import { CartedItem } from '../model/CartedItem';
import { Product } from '../model/Product';
import { CartService } from './cart.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss'],
})
export class CartComponent {
  quantity: number = 1;
  chosenCartItems$ = this.cartService.getChosenCartItems();

  constructor(private cartService: CartService, private router: Router) {}

  // add to card incrementing quantity by 1
  // notify updateCart func with increment type
  incrementQuantity = (item: CartedItem) =>
    this.quantity++ && this.updateCart(item, CartQuantity.Increment);

  // decrement item quantity from card
  // notify updateCart func with increment type
  decrementQuantity = (item: CartedItem) =>
    this.updateCart(item, CartQuantity.Decrement);

  updateCart(item: CartedItem, type: CartQuantity) {
    this.cartService
      .getChosenCartItemsById(item.id)
      .pipe(take(1))
      .subscribe((product) => {
        if (product) {
          if (type === CartQuantity.Increment) {
            this.cartService.addToCart(product, product.quantity + 1);
          }
          if (type === CartQuantity.Decrement && product.quantity > 1) {
            this.cartService.addToCart(product, product.quantity - 1);
          }
        }
      });
  }

  removeItemFromCart(item: Product) {
    this.cartService.removeItemFromCart(item.id);
  }

  // clear cart
  clearCart = () => this.cartService.clearCart();

  // handle user navigation
  toProductsPage = () => this.router.navigate([ApiPaths.Products]);
  toCheckoutPage = () => this.router.navigate([ApiPaths.Checkout]);
}
