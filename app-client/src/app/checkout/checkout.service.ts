import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, map, of, switchMap, take } from 'rxjs';
import { ApiPaths } from 'src/app/enums/api-paths';
import { environment } from 'src/environments/environment.development';
import { CartService } from '../cart/cart.service';
import { CartPayload } from '../models/CartPayload';
import { CartedProductItem } from '../models/CartedProductItem';
import { PurchaseActionResponse } from '../models/UpdatedProductsResponse';

@Injectable({
  providedIn: 'root',
})
export class CheckoutService {
  constructor(private cartService: CartService, private http: HttpClient) {}

  cartPayload: CartPayload = {
    customerId: 1, // to be replaced by real user ID
    cartItems: [],
  };
  purchaseActionResponse: PurchaseActionResponse = {
    success: false,
    message: '',
  };

  purchaseCart(): Observable<PurchaseActionResponse> {
    return this.cartService.selectedCartItems$.pipe(
      take(1),
      switchMap((cartItems) => {
        this.cartPayload.cartItems = cartItems.map(
          (item: CartedProductItem) => ({
            id: item.id,
            quantity: item.quantity,
          }),
        );
        const { baseUrl } = environment;
        const url = `${baseUrl}${ApiPaths.Purchase}`;
        return this.http
          .post<PurchaseActionResponse>(url, this.cartPayload)
          .pipe(
            map((res) => {
              if (res.success) {
                const purchaseActionResponse: PurchaseActionResponse = {
                  success: true,
                  message: res.message,
                };
                this.cartService.clearCart();
                console.log(
                  'purchaseActionResponse;: ',
                  purchaseActionResponse,
                );
                return purchaseActionResponse;
              } else {
                return {
                  success: false,
                  message: res.message,
                };
              }
            }),
            catchError((err) => {
              if (err.status === 400) {
                console.error(
                  `Err occured during processing purchase details: ${err.error.message}`,
                );
                return of({
                  success: false,
                  message: err.error.message,
                });
              } else {
                console.error(
                  `Err occured during fetching response data: ${err.message}`,
                );
                return of({
                  success: false,
                  message:
                    'An error occurred while processing your request. Please try again later.',
                });
              }
            }),
          );
      }),
    );
  }
}
