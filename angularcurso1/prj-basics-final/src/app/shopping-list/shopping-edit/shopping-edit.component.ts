import { Component, OnInit, Output, EventEmitter, Input, ViewChild, ElementRef } from '@angular/core';
import { Ingredient } from '../../shared/ingredient.model';

@Component({
  selector: 'app-shopping-edit',
  templateUrl: './shopping-edit.component.html',
  styleUrls: ['./shopping-edit.component.css']
})
export class ShoppingEditComponent implements OnInit {
  @Output() newIngredient= new EventEmitter<Ingredient>();
  @ViewChild('nameInput') name: ElementRef;
  @ViewChild('amountInput') amount: ElementRef;

  constructor() { }

  ngOnInit() {
  }

  onAddClick(){
    const ing: Ingredient  = new Ingredient(this.name.nativeElement.value, this.amount.nativeElement.value)
    this.newIngredient.emit(ing);
  }


}
