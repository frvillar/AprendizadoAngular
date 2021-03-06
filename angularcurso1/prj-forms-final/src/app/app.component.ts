import { Component, OnInit } from "@angular/core";
import * as firebase from "firebase/app";
import 'firebase/auth';

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
  styleUrls: ["./app.component.css"]
})
export class AppComponent implements OnInit {
  loadedFeature = "recipe";

  onNavigate(feature: string) {
    this.loadedFeature = feature;
  }

  ngOnInit() {
    firebase.initializeApp({
      apiKey: 'AIzaSyCGvf1AyZq4iGRYpUr-jzUMpkC2J_fGANs',
      authDomain: 'ng-recipe-book-d3348.firebaseapp.com'
    });
  }
}
