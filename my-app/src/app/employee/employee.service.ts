import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { MessageService } from '../message.service';
import { Employee } from './employee';

import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};


@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  private employeesUrl = 'api/employees';  // URL to web api
  
  constructor(private http: HttpClient, private msgSer: MessageService) {
  }

  /** GET heroes from the server */
  getAll(): Observable<Employee[]> {
    const url = `${environment.webApiUrl}/${this.employeesUrl}`;

    this.msgSer.add('Called GetALL()');

    return this.http.get<Employee[]>(url)
      .pipe(
        tap(heroes => this.log('fetched heroes')),
        catchError(this.handleError('getHeroes', []))
      );
  }

  /** GET hero by id. Will 404 if id not found */
  getEmployee(id: number): Observable<Employee> {
    const url = `${environment.webApiUrl}/${this.employeesUrl}/${id}`;

    return this.http.get<Employee>(url)
      .pipe(
        tap(_ => this.log(`fetched id=${id}`)),
        catchError(this.handleError<Employee>(`getHero id=${id}`))
      );
  }

  /**
 * Handle Http operation that failed.
 * Let the app continue.
 * @param operation - name of the operation that failed
 * @param result - optional value to return as the observable result
 */
  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      this.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }

  /** Log a HeroService message with the MessageService */
  private log(message: string) {
    this.msgSer.add(`HeroService: ${message}`);
  }

}
