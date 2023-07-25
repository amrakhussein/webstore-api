import { Review } from './Review';

export interface Product {
  id: number;
  description?: string;
  quantity: number;
  imageSrc: string;
  name: string;
  price: number;
  reviews: Review[];
}
