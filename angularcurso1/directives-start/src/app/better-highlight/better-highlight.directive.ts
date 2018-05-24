import { Directive, Renderer2, OnInit, ElementRef, HostListener, HostBinding, Input } from '@angular/core';

@Directive({
  selector: '[appBetterHighlight]'
})
export class BetterHighlightDirective implements OnInit {
  @Input() defaultColor: string = 'Red';
  @Input() highlightColor: string = 'lightBlue';
  @HostBinding('style.backgroundColor') backgroundColor: string;


  constructor(private elRef: ElementRef, private renderer: Renderer2) {
  }

  ngOnInit(){
    //this.renderer.setStyle(this.elRef.nativeElement, 'background-color', 'lightBlue');
    this.backgroundColor = this.defaultColor;
  }

  @HostListener('mouseenter') mouseover(){
    // this.renderer.setStyle(this.elRef.nativeElement, 'background-color', 'lightGreen');
    this.backgroundColor = this.highlightColor;
  }

  @HostListener('mouseleave') mouseleave(){
    // this.renderer.setStyle(this.elRef.nativeElement, 'background-color', 'lightBlue');
    this.backgroundColor = this.defaultColor;
  }

}
