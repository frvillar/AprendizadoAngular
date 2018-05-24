import { Component, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-game-control',
  templateUrl: './game-control.component.html',
  styleUrls: ['./game-control.component.css']
})
export class GameControlComponent implements OnInit {
  @Output() integerCreated = new EventEmitter<number>();
  counter: number=0;
  interval;
  
  constructor() { }

  ngOnInit() {
  }

  onStartGame(){
    this.interval = setInterval(() => {
      this.counter++;
      this.integerCreated.emit(this.counter);
    }, 1000);
  }

  onStopGame(){
    clearInterval(this.interval);
  }

  myFunc(){
    this.counter = this.counter + 1;
  }
  

}
