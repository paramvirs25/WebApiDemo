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

  constructor(private http: HttpClient, private msgSer: MessageService) {
  }

  /** GET heroes from the server */
  getAll(): Observable<Employee[]> {
    this.msgSer.add('Called GetALL()');

    return this.http.get<Employee[]>(this.getEmployeeWebAPiUrl())
      .pipe(
      tap(heroes => console.log(heroes)),
        catchError(this.handleError('getHeroes', []))
      );
  }

  /** GET hero by id. Will 404 if id not found */
  getEmployee(id: number): Observable<Employee> {
    const url = `${this.getEmployeeWebAPiUrl()}/${id}`;

    return this.http.get<Employee>(url)
      .pipe(
        tap(_ => this.log(`fetched id=${id}`)),
        catchError(this.handleError<Employee>(`getHero id=${id}`))
      );
  }

  /** PUT: update the employee on the server */
  update(emp: Employee){

    console.log('Service called')
    console.log(emp)

    //`${api}/hero/`
    const url = `${this.getEmployeeWebAPiUrl()}/PostEmployee`;
    //return this.http.post<String>(url, "Hello", httpOptions);
    return this.http.post<Employee>(url, emp, httpOptions);

    //const url = `${environment.webApiUrl}${this.employeesUrl}?id=${emp.Id}`;

    //return this.http.put<Employee>(url, emp, httpOptions);

    //return this.http.put(url, emp, httpOptions).
    //  pipe(tap(_ => this.log(`updated employee id=${emp.Id}`)),
    //    catchError(this.handleError<any>('updateHero'))
    //  );
  }

  /** Delete hero by id*/
  deleteEmployee(id: number): Observable<Employee[]> {
    const url = `${this.getEmployeeWebAPiUrl()}/${id}`;

    return this.http.delete<Employee>(url)
      .pipe(
        tap(_ => this.log(`fetched id=${id}`)),
        catchError(this.handleError<Employee>(`getHero id=${id}`))
      );
  }

  /**Get Url to WebApi**/
  private getEmployeeWebAPiUrl(): string {
    return `${environment.webApiUrl}Employees1`;
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
