import { Component } from '@angular/core';
import { OnInit } from '@angular/core';
import { ProductService } from 'src/app/services/product.service';
import { Product } from '../../models/Product';
import { NgForm } from '@angular/forms'; 
import Swal from 'sweetalert2';


@Component ({
  selector: 'app-product',
  templateUrl: './product.component.html',
})


export class ProductComponent implements OnInit {

  products: Product
  
  selectedProduct: Product = new Product ();   

 
  constructor(
    protected _productServices : ProductService                  
    ){}


 getAllProducts(){
      this._productServices.getProducts().subscribe(p=>{
        if(p){
            this.products = p.data;
        }
    });    
    }  

  ngOnInit(): void {
       //traemos product de la bd      
       this.getAllProducts();

  }

 
  
  guardarProduct(form:NgForm){
    if(form.invalid){
        console.log("Formulario invalido");
        return;
    }
  
    if(this.selectedProduct.productId===0){
       Swal.fire({
        title: '¿Estas seguro de guardar el producto?',
        text: "Se guardara el producto en la base de datos",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Si, Guardar!'
      }).then((result) => {
        if (result.isConfirmed) {
          this._productServices.createProduct(this.selectedProduct).subscribe(p=>{
            if(p){
             this.alerteExitosa("Guardado","El producto ha sido guardado");
              this.getAllProducts();
              this.selectedProduct= new Product();
            }
          });
        }
      })
     
    }else{
        Swal.fire({
            title: '¿Estas seguro?',
            text: "Se modificaran los datos!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Si, actualizar!'
          }).then((result) => {
            if (result.isConfirmed) {
              this._productServices.updateProduct(this.selectedProduct).subscribe(p=>{
                if(p){
                   console.log("actualizado")
                   this.getAllProducts();
                   this.selectedProduct= new Product();
                }
            });
              this.alerteExitosa("Actualizado","El producto ha sido actualizado");              
            }
          }
          )
    }
  }


  editProduct(  product: Product){   
    this.selectedProduct = product;
    
  }

  deleteProduct(product:Product){
    
    Swal.fire({
      title: 'Estas seguro?',
      text: "No podras revertir esta accion!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Si, eliminar!'
    }).then((result) => {
      if (result.isConfirmed) {
        this._productServices.deleteProduct(product).subscribe(p=>{
          if(p){            
            this.getAllProducts();
          }
        });
       this.alerteExitosa("Eliminado","El producto ha sido eliminado");
      }
    }
    )   

  }


  alerteExitosa(title:string,text:string ){
    Swal.fire({
      title: title,
      text: text,
      icon: 'success',
      confirmButtonText: 'Ok'
    })


  }

  }

