import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Rating } from 'src/app/model/BookRating';
import { ProductService } from '../product.service';

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
  product$!: unknown;

  constructor(
    private productService: ProductService,
    private route: ActivatedRoute
  ) {
    this.route.params.subscribe((params) => {
      const productId = Number(params['productId']);
      this.id = productId;
      console.log('productId: ', productId);
      this.getProductById();
    });
  }
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
    this.product$ = this.productService.getProductById(this.id);
  }
  onRatingChange(evt: Event) {
    const target = evt.target as HTMLButtonElement;
    this.stars = Number(target.value);
  }
}
