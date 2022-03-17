import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
const baseURL = 'https://localhost:44342/api/v1/PhoneBook';

 const httpOptions = { headers: new HttpHeaders({ 'Access-Control-Allow-Origin': '*'}) };

@Injectable({
  providedIn: 'root'
})
export class PhonebookService {
 
  constructor(private httpClient: HttpClient) { }

  getPhonebookList(): Observable<any> {
    return this.httpClient.get(baseURL+'/get-phonebook-list', httpOptions );
  }
  createPhoneBook(data): Observable<any> {
    return this.httpClient.post(baseURL+ '/create-phonebook', data, httpOptions);
  }
}
