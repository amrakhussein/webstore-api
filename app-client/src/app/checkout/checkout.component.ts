import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { CartService } from '../cart/cart.service';
import { ApiPaths } from '../enums/api-paths';
import { CartedProductItem } from '../models/CartedProductItem';
import { CheckoutService } from './checkout.service';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.scss'],
})
export class CheckoutComponent {
  successStatus!: boolean;
  orderStatus!: string;
  selectedCartItems$ = this.cartService.selectedCartItems$;

  purchaseActionResponse!: string;

  constructor(
    private checkoutService: CheckoutService,
    private cartService: CartService,
    private router: Router,
  ) {}

  // total amount
  getTotalAmount = (cartItems: CartedProductItem[]) =>
    cartItems?.reduce((total, item) => total + item.quantity * item.price, 0);

  purchaseCart() {
    this.checkoutService.purchaseCart().subscribe((result) => {
      this.orderStatus = result.message;
      this.successStatus = result.success;
    });
  }

  // handle user navigation
  toProductsPage = () => this.router.navigate([ApiPaths.Products]);
}
