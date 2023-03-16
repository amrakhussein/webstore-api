import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ProductService } from './../product.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.scss'],
})
export class ProductListComponent {
  selectedItemsCount: number = 0;
  products$ = this.productService.getAllProducts();

  constructor(private productService: ProductService, private router: Router) {}

  goToCart() {
    this.router.navigate(['/cart']);
  }
}
