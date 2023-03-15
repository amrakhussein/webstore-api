import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ProductListComponent } from './product-list/product-list.component';
import { ProductCardComponent } from './product-card/product-card.component';


@NgModule({
  declarations: [ProductListComponent, ProductCardComponent],
  imports: [CommonModule, RouterModule],
  exports: [ProductListComponent, ProductCardComponent],
})
export class ProductsModule {}
