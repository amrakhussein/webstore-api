import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Rating } from 'src/app/model/BookRating';
import { ProductService } from '../product.service';
import { CartAction } from 'src/app/constants/cart-action';
import { CartService } from 'src/app/cart/cart.service';
import { Product } from 'src/app/models/Product';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss'],
})
export class ProductDetailsComponent {
  stars: number = 0;
  review!: string;
  successRatingStatus!: boolean;
  id!: number;
  product!: unknown;
  selectedQuantity: number = 0;

  constructor(
    private productService: ProductService,
    private route: ActivatedRoute,
    private cartService: CartService
  ) {
    this.route.params.subscribe((params) => {
      const productId = Number(params['productId']);
      this.id = productId;
      console.log('productId: ', productId);
      this.getProductById();
    });
  }
  ngOnInit(): void {
    this.cartService
      .getChosenCartItemsById(Number(this.id))
      .subscribe((selected) => {
        console.log(' selected?.id: ', selected);
        console.log(' selected?.id: ', selected?.quantity);
        this.selectedQuantity = selected!.quantity;
      });
  }
  // add to card incrementing quantity by 1
  incrementQuantity = () => {
    this.selectedQuantity++;
    this.addToCart(this.product, CartAction.Increment);
  };

  // decrement item quantity from card when quantity is bigger than 1
  decrementQuantity = () => {
    if (this.selectedQuantity >= 1) {
      this.selectedQuantity--;
      this.addToCart(this.product, CartAction.Decrement);
    }
  };

  // add choosen product to card
  private addToCart = (product: Product, cartAction: CartAction) =>
    this.cartService.addToCart(product, cartAction);

  addRating(): void {
    const rating: Rating = {
      stars: this.stars,
      review: this.review,
    };
    this.productService.addRating(this.id, rating).subscribe((data) => {
      // recall get book by id, to reflect changes
      this.getProductById();
      // clear user input upon submit
      this.stars = 0;
      this.review = '';
    });
  }
  getProductById() {
    this.productService.getProductById(this.id).subscribe(product => {
      this.product = product
    })
  }
  onRatingChange(evt: Event) {
    const target = evt.target as HTMLButtonElement;
    this.stars = Number(target.value);
  }
}
