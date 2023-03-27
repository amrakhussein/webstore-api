import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ContainerComponent } from './container/container.component';
import { TheHeaderComponent } from './the-header/the-header.component';
import { TheFooterComponent } from './the-footer/the-footer.component';
import { ProductListComponent } from './products/product-list/product-list.component';
import { ProductsModule } from './products/products.module';
import { CartComponent } from './cart/cart.component';
import { CheckoutComponent } from './checkout/checkout.component';
import { ProductDetailsComponent } from './products/product-details/product-details.component';


@NgModule({
  declarations: [
    AppComponent,
    TheHeaderComponent,
    TheFooterComponent,
    ContainerComponent,
    CartComponent,
    CheckoutComponent,
    ProductDetailsComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    ProductsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
