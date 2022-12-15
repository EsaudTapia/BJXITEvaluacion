import { Component } from '@angular/core';
import { OnInit } from '@angular/core';
import { ProductService } from 'src/app/services/product.service';
import { Product } from '../../models/Product';

@Component ({
  selector: 'app-home',
  templateUrl: './home.component.html',
})


export class HomeComponent implements OnInit {

  product: Product
  

  constructor(
    protected _productServices : ProductService    

    ){}

  ngOnInit(): void {
   

  }
}
