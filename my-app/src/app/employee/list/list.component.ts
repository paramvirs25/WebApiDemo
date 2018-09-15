import { Component, OnInit } from '@angular/core';

import { EmployeeService } from '../employee.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {

  employees: object[];

  constructor(private employeeService: EmployeeService) { }

  ngOnInit() {
    this.employees = [];
    this.getAllEmployees();
  }

  getAllEmployees(): void {
    this.employeeService.getAll().subscribe(emp => this.employees = emp);
  }

}
