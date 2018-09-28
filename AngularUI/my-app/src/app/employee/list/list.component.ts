import { Component, OnInit } from '@angular/core';
import { Employee } from '../employee';

import { EmployeeService } from '../employee.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {

  employees: Employee[];

  constructor(private employeeService: EmployeeService) { }

  ngOnInit() {
    this.employees = [];
    this.getAllEmployees();
  }

  getAllEmployees(): void {
    this.employeeService.getAll().subscribe(emp => this.employees = emp);
  }

  deleteEmployee(emp: Employee): void {
    this.employeeService.deleteEmployee(emp.Id).subscribe(empDeleted => this.deleteComplete());
  }

  deleteComplete() {
    this.getAllEmployees();
  }
}
