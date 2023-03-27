import { CommonModule } from '@angular/common';
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ProductCardComponent } from './product-card/product-card.component';
import { ProductListComponent } from './product-list/product-list.component';

@NgModule({
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  declarations: [ProductListComponent, ProductCardComponent],
  imports: [CommonModule, RouterModule],
  exports: [ProductListComponent, ProductCardComponent],
})
export class ProductsModule {}
