import { Component, Input } from '@angular/core';
import { CartService } from 'src/app/cart/cart.service';
import { CartAction } from 'src/app/enums/card-action';
import { Product } from 'src/app/model/Product';

@Component({
  selector: 'app-product-card',
  templateUrl: './product-card.component.html',
  styleUrls: ['./product-card.component.scss'],
})
export class ProductCardComponent {
  quantity: number = 0;
  @Input() product!: Product;

  constructor(private cartService: CartService) {}

  // add to card incrementing quantity by 1
  incrementQuantity = () => {
    this.quantity++;
    this.addToCart(this.product);
      // notify quantity count observer for header cart update
    this.cartService.updateQuantityCount(CartAction.Increment);
  };

  // decrement item quantity from card when quantity is bigger than 1
  decrementQuantity = () => {
    if (this.quantity >= 1) {
      this.quantity--;
      this.addToCart(this.product);
      // notify quantity count observer for header cart update
      this.cartService.updateQuantityCount(CartAction.Decrement);
    }
  };

  // add choosen product to card
  addToCart = (product: Product) => {
    this.cartService.addToCart(product, this.quantity);
  };
}
