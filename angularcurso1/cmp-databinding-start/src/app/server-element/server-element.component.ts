import { Component, OnInit,Input, OnChanges, SimpleChanges } from '@angular/core';

@Component({
  selector: 'app-server-element',
  templateUrl: './server-element.component.html',
  styleUrls: ['./server-element.component.css']
})
export class ServerElementComponent implements OnInit, OnChanges {
  @Input('srvElement') element: {type: string, name: string, content: string};

  constructor() { 
    console.log('Constructor server-element');
  }

  ngOnInit() {
    console.log('ng init server-element');
  }

  ngOnChanges(changes: SimpleChanges) {
    console.log('on Changes server-element');
    console.log(changes);
  }

}
