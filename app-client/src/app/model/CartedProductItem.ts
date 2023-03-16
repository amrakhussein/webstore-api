import { CartedItem } from './CartedItem';
import { Product } from './Product';

export interface CartedProductItem extends CartedItem, Product {}
