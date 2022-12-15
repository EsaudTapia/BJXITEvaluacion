import { Component } from '@angular/core';
import { OnInit } from '@angular/core';
import { ClientService } from 'src/app/services/client.service';
import { NgForm } from '@angular/forms'; 
import Swal, { SweetAlertIcon } from 'sweetalert2';
import { Client } from '../../models/Client';


@Component ({
  selector: 'app-client',
  templateUrl: './client.component.html',
})

export class ClientComponent implements OnInit {
    clients: Client
  
    selectedClient: Client = new Client ();   
  
   
    constructor(
      protected _clientServices : ClientService                  
      ){}


  alert(title: string, text: string, icon: SweetAlertIcon='success') {
        Swal.fire({
          title: title,
          text: text,
          icon: icon,
          confirmButtonText: 'Ok'
        })    
      }

      getAllClients(){
        this._clientServices.getClient().subscribe(p=>{
          if(p){
              this.clients = p.data;
          }
      });    
      }

      ngOnInit(): void {
        //traemos client de la bd              
       this.getAllClients();           
    }


    guardarClient(form:NgForm){
        if(form.invalid){
            console.log("Formulario invalido");
            return;
        }
      
        if(this.selectedClient.clientId===0){
           Swal.fire({
            title: '¿Estas seguro de guardar el cliente?',
            text: "Se guardara el cliente en la base de datos",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Si, Guardar!'
          }).then((result) => {
            if (result.isConfirmed) {
              this._clientServices.createClient(this.selectedClient).subscribe(p=>{
                if (p) {
                  if (p.data.data == -1) {
                    return this.alert("Intente de nuevo", "El cliente ya existe con ese correo","error");                     
                  }
                 this.alert("Guardado","El cliente ha sido guardado");
                  this.getAllClients();
                  this.selectedClient = new Client();
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
                  this._clientServices.updateClient(this.selectedClient).subscribe(p=>{
                    if(p){

                      if(p.data.data == -1){
                        return this.alert("Intente de nuevo", p.data.message,"error");
                      }else{
                        
                        
                        console.log("actualizado")
                        this.getAllClients();
                        this.selectedClient= new Client();
                      
                      }
                      this.alert("Actualizado","El cliente ha sido actualizado");  
                     
                    }
                });
                           
                }
              }
              )
        }                
      }

      editClient(  client: Client){   
        this.selectedClient = client;        
      }

      deleteClient(client: Client){
        Swal.fire({
          title: '¿Estas seguro?',
          text: "Se eliminara el cliente!",
          icon: 'warning',
          showCancelButton: true,
          confirmButtonColor: '#3085d6',
          cancelButtonColor: '#d33',
          confirmButtonText: 'Si, Eliminar!'
        }).then((result) => {
          if (result.isConfirmed) {
            this._clientServices.deleteClient(client).subscribe(p=>{
              if(p){
                if(p.data.data == -1){
                  return this.alert("Intente de nuevo", p.data.message,"error");
                }
                this.alert("Eliminado","El cliente ha sido eliminado");  
                this.getAllClients();
              }
          });
          }
        })
      }

   
}
