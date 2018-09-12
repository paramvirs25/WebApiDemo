import { Component, OnInit } from '@angular/core';

import { EmployeeService } from '../employee.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {

  employees: string;

  constructor(private employeeService: EmployeeService) { }

  ngOnInit() {
    this.getAllEmployees();
  }

  getAllEmployees(): void {
    this.employees = this.employeeService.getAll();
  }

}
