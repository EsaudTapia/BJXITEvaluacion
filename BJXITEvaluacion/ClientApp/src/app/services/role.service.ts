import { HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ResponseDataDto } from '../models/ResponseDataDto';
import { BaseService } from './base.service';
import { Role } from '../models/Role';

@Injectable({
  providedIn: 'root'
})

export class RoleService  extends BaseService  {

  private _BaseUrl= 'api/role';

  getRoles(): Observable<ResponseDataDto> {
    return this._httpClient.get<ResponseDataDto>(this._BaseUrl)
      .catch(this.handleError);
  }

  createRole (role: Role): Observable<ResponseDataDto> {
    return this._httpClient.post<ResponseDataDto>(this._BaseUrl, role)
      .catch(this.handleError);
  }

  updateRole (role: Role): Observable<ResponseDataDto> {
    return this._httpClient.put<ResponseDataDto>(this._BaseUrl, role)
      .catch(this.handleError);
  }

  deleteRole (role: Role): Observable<ResponseDataDto> {
    return this._httpClient.request<ResponseDataDto>('delete', this._BaseUrl, { body: role })
      .catch(this.handleError);
  }


 
}
