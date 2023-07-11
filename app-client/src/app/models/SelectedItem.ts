import { Product } from './Product';

export interface SelectedItem extends Product {
  id: number;
  quantity: number;
}
