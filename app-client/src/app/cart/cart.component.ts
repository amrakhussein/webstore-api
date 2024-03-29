import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { take } from 'rxjs';
import { CartAction } from '../constants/cart-action';
import { ApiPaths } from '../enums/api-paths';
import { CartedProductItem } from '../models/CartedProductItem';
import { SelectedItem } from '../models/SelectedItem';
import { CartService } from './cart.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss'],
})
export class CartComponent {
  quantity!: number;
  chosenCartItems$ = this.cartService.selectedCartItems$;

  constructor(private cartService: CartService, private router: Router) {}

  // add to card incrementing quantity by 1
  // notify updateCart func with increment type
  incrementQuantity = (item: CartedProductItem) => {
    this.quantity++;
    this.updateCart(item, CartAction.Increment);
  };

  // decrement item quantity from card
  // notify updateCart func with increment type
  decrementQuantity = (item: SelectedItem) => {
    this.quantity--;
    this.updateCart(item, CartAction.Decrement);
  };

  private updateCart(item: SelectedItem, cartAction: CartAction) {
    this.cartService
      .getChosenCartItemsById(item.id)
      .pipe(take(1))
      .subscribe((product) => {
        if (product) {
          this.cartService.addToCart(product, cartAction);
        }
      });
  }

  removeItemFromCart(item: SelectedItem) {
    this.cartService.removeItemFromCart(item.id);
  }

  // clear cart
  clearCart = () => this.cartService.clearCart();

  // total amount
  getTotalAmount = (cartItems: CartedProductItem[]) =>
    cartItems.reduce((total, item) => total + item.quantity * item.price, 0);

  // handle user navigation
  toProductsPage = () => this.router.navigate([ApiPaths.Products]);
  toCheckoutPage = () => this.router.navigate([ApiPaths.Checkout]);
}
