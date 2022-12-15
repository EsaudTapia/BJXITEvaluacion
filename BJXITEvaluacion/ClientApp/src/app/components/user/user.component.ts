import { Component } from '@angular/core';
import { OnInit } from '@angular/core';
import { UserService } from 'src/app/services/user.service'; 
import { RoleService } from 'src/app/services/role.service'; 
import { NgForm } from '@angular/forms'; 
import Swal, { SweetAlertIcon } from 'sweetalert2';
import { User } from '../../models/User';
import { Role } from '../../models/Role';


@Component ({
    selector: 'app-user',
    templateUrl: './user.component.html'
})


export class UserComponent implements OnInit {

    roles:Role
    users: User
    

    selectedUser: User = new User ();   
    selectedRole: Role = new Role ();   

    
    constructor(
      protected _userServices : UserService   , 
      protected _roleServices : RoleService                  
      ){}

    alert(title: string, text: string, icon: SweetAlertIcon='success') {
        Swal.fire({
            title: title,
            text: text,
            icon: icon,
            confirmButtonText: 'Ok'
        })
    }

    getAllUser(){
        this._userServices.getUsers().subscribe(p=>{
            if(p){
                this.users = p.data;
            }
        });
    }

    getAllRole(){
        this._roleServices.getRoles().subscribe(p=>{
            if(p){
                this.roles = p.data;
            }
        });
    }


   
    ngOnInit(): void {   
        //traemos usuarios de la bd                 
        this.getAllRole(); 
        this.getAllUser(); 
            
              
    }

    guardarUser(form:NgForm){
        if(form.invalid){
            this.alert("Formulario invalido","Porfavor llene todo los campos","info");
            return;
        }
      
        if(this.selectedUser.userId===0){
            Swal.fire({
                title: '¿Estas seguro de guardar el usuario?',
                text: "Se guardara el usuario en la base de datos",
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Si, guardar!'
              }).then((result) => {
                if (result.isConfirmed) {
                    this._userServices.createUser(this.selectedUser).subscribe(p=>{
                        if(p){

                            if(p.data.data==-1){                                    
                                return this.alert("Intente de nuevo", p.data.message,"error");
                            }

                            this.alert('Usuario', 'Usuario guardado con exito', 'success');
                            this.selectedUser = new User();
                            this.getAllUser();
                        }
                    });
                }
              })
        }
        else{
            Swal.fire({
                title: '¿Estas seguro de actualizar el usuario?',
                text: "Se actualizara el usuario en la base de datos",
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Si, actualizar!'
              }).then((result) => {
                if (result.isConfirmed) {
                    this._userServices.updateUser(this.selectedUser).subscribe(p=>{
                        if(p){

                            if(p.data.data==-1){
                                return this.alert("Intente de nuevo", p.data.message,"error");

                            }

                            this.alert('Usuario', 'Usuario actualizado con exito', 'success');
                            this.selectedUser = new User();
                            this.getAllUser();
                        }
                    });
                }
              })
        }

    }

    deleteUser(user:User){
        Swal.fire({
            title: '¿Estas seguro de eliminar el usuario?',
            text: "Se eliminara el usuario en la base de datos",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Si, eliminar!'
          }).then((result) => {
            if (result.isConfirmed) {
                this._userServices.deleteUser(user).subscribe(p=>{
                    if(p){
                        this.alert('Usuario', 'Usuario eliminado con exito', 'success');
                        this.selectedUser = new User();
                        this.getAllUser();
                    }
                });
            }
          })
    }


    updateUser(user:User){
        this.selectedUser = user;
    }
}
