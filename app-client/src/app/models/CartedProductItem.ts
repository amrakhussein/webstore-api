import { Product } from './Product';
import { SelectedItem } from './SelectedItem';

export interface CartedProductItem
  extends SelectedItem,
    Pick<
      Product,
      'id' | 'name' | 'description' | 'quantity' | 'imageSrc' | 'price'
    > {}
