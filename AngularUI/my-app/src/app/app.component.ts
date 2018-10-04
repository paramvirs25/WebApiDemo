import { Component } from '@angular/core';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Angular UI that consumes WebAPI written in .net';

  color = 'primary';
  mode = 'determinate';
  value = 50;
  bufferValue = 75;
}
