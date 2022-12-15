import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpResponse } from '@angular/common/http';
import { HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { throwError } from 'rxjs';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import { ResponseDto } from '../models/ResponseDto';



@Injectable()
export class BaseService {
  private static that;

  constructor(protected _httpClient: HttpClient) {
     BaseService.that = this;
   }
 
 
 
  // Utility
   protected handleError(error: HttpErrorResponse) {
     let customError: string = null;
 
 
 
    if (error.error) {
       customError = error.status === 400 ? error.error : error.status === 500 ? error.error.Detail:null;
     }
  
     let title ="error";
     let detail = customError || "server error"; 
 
    return throwError(detail);
   }
 
 
 
  protected processResponse<T extends ResponseDto>(response: T) {
     if (!response.completed) {
       let title = "error";        
     }
   }
 
 

}
