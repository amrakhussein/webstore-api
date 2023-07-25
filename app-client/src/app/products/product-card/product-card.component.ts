import { Component, Input } from '@angular/core';
import { CartService } from 'src/app/cart/cart.service';
import { CartAction } from 'src/app/constants/cart-action';
import { Product } from 'src/app/model/Product';

@Component({
  selector: 'app-product-card',
  templateUrl: './product-card.component.html',
  styleUrls: ['./product-card.component.scss'],
})
export class ProductCardComponent {
  @Input() product!: Product;
  selectedQuantity: number = 0;
  chosenCartItems$ = this.cartService.selectedCartItems$;
  
  constructor(private cartService: CartService) {}
  
  // add to card incrementing quantity by 1
  incrementQuantity = () => {
    this.selectedQuantity++;
    this.addToCart(this.product, CartAction.Increment);
  };

  showIncrementCount = () => {
    console.log('OER WORDS expected');
    this.cartService
      .getChosenCartItemsById(Number(this.product.id))
      .subscribe((selected) => {
        console.log(' selected?.id: ', selected);
        console.log(' selected?.id: ', selected?.quantity);
        if (selected?.quantity) {
          this.selectedQuantity = selected.quantity;
        }
      });
  };

  // decrement item quantity from card when quantity is bigger than 1
  decrementQuantity = () => {
    if (this.selectedQuantity >= 1) {
      this.selectedQuantity--;
      this.addToCart(this.product, CartAction.Decrement);
    }
  };

  // add choosen product to card only when add button is active
  addToCart = (product: Product, cartAction: CartAction) => {
    this.cartService.addToCart(product, cartAction);
  };
}
