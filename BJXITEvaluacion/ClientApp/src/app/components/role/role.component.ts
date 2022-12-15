import { AfterViewInit, Component } from '@angular/core';
import { OnInit } from '@angular/core';
import { RoleService } from 'src/app/services/role.service';
import { NgForm } from '@angular/forms'; 
import Swal, { SweetAlertIcon } from 'sweetalert2';
import { Role } from '../../models/Role';

declare const $:any;

@Component ({
    selector: 'app-role',
    templateUrl: './role.component.html'
})


export class RoleComponent implements OnInit, AfterViewInit {

    roles: Role
  
    selectedRole: Role = new Role ();   
  
   
    constructor(
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

    getAllRole(){
        this._roleServices.getRoles().subscribe(p=>{
            if(p){
                this.roles = p.data;
            }
        });
    }

    ngAfterViewInit(): void {
      $('#tbRole').DataTable(); 
    }

      ngOnInit(): void {
        //traemos client de la bd              
       this.getAllRole();           
    }

    
  guardarRole(form:NgForm){
    if(form.invalid){
        console.log("Formulario invalido");
        return;
    }

    if(this.selectedRole.roleId===0){

        Swal.fire({
            title: '¿Estas seguro de guardar el rol?',
            text: "Se guardara el rol en la base de datos",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Si, Guardar!'
          }).then((result) => {
            if (result.isConfirmed) {
              this._roleServices.createRole(this.selectedRole).subscribe(p=>{
                if(p){
                    this.alert('Rol', 'Rol guardado con exito');
                    this.getAllRole();
                    this.selectedRole= new Role();
                }
            });
            }
          })
    }else{
        Swal.fire({
            title: '¿Estas seguro de actualizar el rol?',
            text: "Se actualizara el rol en la base de datos",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Si, Actualizar!'
          }).then((result) => {
            if (result.isConfirmed) {
              this._roleServices.updateRole(this.selectedRole).subscribe(p=>{
                if(p){
                    this.getAllRole();
                    this.selectedRole= new Role();
                }
            });
            this.alert('Rol', 'Rol actualizado con exito');
            }
          })
    }


}

editRole(role: Role){
    this.selectedRole = role;
}

deleteRole(role: Role){

    Swal.fire({
        title: '¿Estas seguro de eliminar el rol?',
        text: "Se eliminara el rol en la base de datos",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Si, Eliminar!'
      }).then((result) => {
        if (result.isConfirmed) {
          this._roleServices.deleteRole(role).subscribe(p=>{
            if(p){
                this.getAllRole();
            }
        });
        this.alert('Rol', 'Rol eliminado con exito');
        }
      })
}


}