import { Component, OnInit } from '@angular/core';

import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

import { Employee } from '../employee';
import { EmployeeService } from '../employee.service';


@Component({
  selector: 'app-detail',
  templateUrl: './detail.component.html',
  styleUrls: ['./detail.component.css']
})
export class DetailComponent implements OnInit {

  employee: Employee;

  constructor(
    private route: ActivatedRoute,
    private employeeService: EmployeeService,
    private location: Location
  ) { }

  ngOnInit() {
    this.getEmployee();
  }

  getEmployee(): void {
    const id = +this.route.snapshot.paramMap.get('id');

    if (id == 0) {
      this.employee = new Employee();
      this.employee.Id = 0;
    }
    else {
      this.employeeService.getEmployee(id).subscribe(emp => this.employee = emp);
    }
  }

  save(): void {
    console.log(this.employee);
    this.employeeService.update(this.employee)
      .subscribe(() => this.goBack());
  }

  goBack(): void {
    this.location.back();
  }


}
