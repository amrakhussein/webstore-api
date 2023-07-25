import { Product } from './Product';

export interface SelectedProductItems extends Product {
  selectedQuantity: number;
}
