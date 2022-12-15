import { HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ResponseDataDto } from '../models/ResponseDataDto';
import { BaseService } from './base.service';
import { Client } from '../models/Client';


@Injectable({
  providedIn: 'root'
})
export class ClientService extends BaseService {
  private _BaseUrl = 'api/client';  
  
  getClient(): Observable<ResponseDataDto> {
    return this._httpClient.get<ResponseDataDto>(this._BaseUrl)
      .catch(this.handleError);
  }
 

  createClient(client: Client): Observable<ResponseDataDto> {
    return this._httpClient.post<ResponseDataDto>(this._BaseUrl, client)
      .catch(this.handleError);
  }


  updateClient(client: Client): Observable<ResponseDataDto> {
    return this._httpClient.put<ResponseDataDto>(this._BaseUrl, client)
      .catch(this.handleError);
  }

  deleteClient(client: Client): Observable<ResponseDataDto> {     
    return this._httpClient.request<ResponseDataDto>('delete', this._BaseUrl, { body: client })
      .catch(this.handleError);    
  }
}
