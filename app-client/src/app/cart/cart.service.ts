import { Injectable } from '@angular/core';
import {
  BehaviorSubject,
  Observable,
  combineLatest,
  map,
  switchMap,
} from 'rxjs';
import { CartedItem } from '../model/CartedItem';
import { Product } from '../model/Product';
import { SelectedItem } from '../model/SelectedItem';
import { ProductService } from '../products/product.service';

@Injectable({
  providedIn: 'root',
})
export class CartService {
  private selectedCartItems: SelectedItem[] = [];
  selectedCartItems$ = new BehaviorSubject<SelectedItem[]>([]);
  selectedProducts$ = this.getChosenProducts();

  constructor(private productService: ProductService) {}

  getCartItems = () => this.selectedCartItems$;

  getChosenProducts(): Observable<Product[]> {
    return this.productService
      .getAllProducts()
      .pipe(
        switchMap((products) =>
          this.selectedCartItems$.pipe(
            map((selectedItems) =>
              products.filter((p) =>
                selectedItems.some((selected) => selected.id === p.id)
              )
            )
          )
        )
      );
  }

  getChosenCartItemsById(id: number): Observable<Product | undefined> {
    return this.selectedCartItems$.pipe(
      map((products) => products.find((product) => product.id === id))
    );
  }

  getChosenCartItems(): Observable<CartedItem[]> {
    return combineLatest([
      this.selectedProducts$,
      this.selectedCartItems$,
    ]).pipe(
      map(([products, cartItems]) => {
        const chosenCartItems: CartedItem[] = products.map((product) => {
          const cartItem = cartItems.find((item) => item.id === product.id);
          const quantity = cartItem ? cartItem.quantity : 1;

          return {
            id: product.id,
            quantity,
            name: product.name,
            imageSrc: product.imageSrc,
            price: product.price,
          };
        });
        return chosenCartItems;
      })
    );
  }

  addToCart(product: Product, quantity: number = 1) {
    if (!product) return;

    const productWithQuantity: Product = {
      ...product,
      quantity,
    };

    const productIdx = this.selectedCartItems.findIndex(
      (p: SelectedItem) => p.id === productWithQuantity.id
    );

    if (productIdx !== -1) {
      // update item quantity in cart
      this.selectedCartItems[productIdx].quantity = quantity;
    } else {
      // add new item to card if not added before
      this.selectedCartItems.push({
        // TODO: refactor
        ...product,
        id: productWithQuantity.id,
        quantity: productWithQuantity.quantity,
      });
    }
    this.selectedCartItems$.next(this.selectedCartItems);
  }

  public removeItemFromCart(itemId: number): void {
    const index = this.selectedCartItems.findIndex(
      (item) => item.id === itemId
    );
    if (index !== -1) {
      this.selectedCartItems.splice(index, 1);
      this.selectedCartItems$.next(this.selectedCartItems);
    }
  }

  public clearCart = () => this.selectedCartItems$.next([]);
}
