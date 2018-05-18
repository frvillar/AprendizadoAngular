import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent {
  showSecret= false;
  details=[];
  i:number;
  
  constructor() { 
  }

  onDisplayDetails(event: Event){
    this.showSecret = true;
    
    this.i =  this.details.length;
    var d = new Date();

    this.details.push((this.i + 1).toString() + " (timestamp): " + d.getTime());

  }


}


