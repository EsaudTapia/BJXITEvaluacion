import { HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ResponseDataDto } from '../models/ResponseDataDto';
import { BaseService } from './base.service';
import { User } from '../models/User';

@Injectable({
  providedIn: 'root'
})
export class UserService  extends BaseService {

  private _BaseUrl= 'api/user';

  getUsers(): Observable<ResponseDataDto> {
    return this._httpClient.get<ResponseDataDto>(this._BaseUrl)
      .catch(this.handleError);
  }

  createUser (user: User): Observable<ResponseDataDto> {
    return this._httpClient.post<ResponseDataDto>(this._BaseUrl, user)
      .catch(this.handleError);
  }

  updateUser (user: User): Observable<ResponseDataDto> {
    return this._httpClient.put<ResponseDataDto>(this._BaseUrl, user)
      .catch(this.handleError);
  }

  deleteUser (user: User): Observable<ResponseDataDto> {
    return this._httpClient.request<ResponseDataDto>('delete', this._BaseUrl, { body: user })
      .catch(this.handleError);
  }

}
