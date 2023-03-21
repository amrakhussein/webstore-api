import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { CartService } from '../cart/cart.service';

@Component({
  selector: 'app-the-header',
  templateUrl: './the-header.component.html',
  styleUrls: ['./the-header.component.scss'],
})
export class TheHeaderComponent {
  selectedItemsCount$: Observable<number> =
    this.cartService.selectedItemsCount$;
  constructor(private cartService: CartService) {}
}
