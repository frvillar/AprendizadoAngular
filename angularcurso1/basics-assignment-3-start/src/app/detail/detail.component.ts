import { Component } from '@angular/core';

@Component({
  selector: 'app-detail',
  templateUrl: './detail.component.html',
  styleUrls: ['./detail.component.css']
})
export class DetailComponent {

  detail: string;

  constructor() {
    var d = new Date();
    this.detail =   " Timestamp: " + d.getTime();
    console.log('Detail');
   }

   getColor() {
    return 'LightBlue';
  }

}
