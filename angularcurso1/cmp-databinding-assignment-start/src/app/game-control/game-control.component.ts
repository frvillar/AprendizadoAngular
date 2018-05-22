import { Component, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-game-control',
  templateUrl: './game-control.component.html',
  styleUrls: ['./game-control.component.css']
})
export class GameControlComponent implements OnInit {
  @Output() evenCreated = new EventEmitter<{counter:number}>();
  @Output() odCreated = new EventEmitter<{counter:number}>();
  counter: number=0;
  isEven: boolean= true;
  gameOn: boolean=true;
  interval;
  
  constructor() { }

  ngOnInit() {
  }

  onStartGame(){
    this.interval = setInterval(() => {
      this.counter++;
      console.log(this.counter);
    }, 1000);
    // if (this.interval){
    //   clearInterval(this.interval);
    //   console.log(this.counter);
    // }
    // if (this.counter>5){
    //   this.gameOn = false;
    // }
  }

  onStopGame(){
    clearInterval(this.interval);
  }

  myFunc(){
    this.counter = this.counter + 1;
  }
  

}
