// import { map, catchError } from 'rxjs/operators';
import * as firebase from 'firebase/app';
import 'firebase/auth';
import { Router } from '@angular/router';
import { Injectable } from '@angular/core';

@Injectable()
export class AuthService {
  token: string;

  constructor(private router: Router) {}

  signupUser(email: string, senha: string) {
    firebase.auth().createUserWithEmailAndPassword(email, senha)
      .catch(
        error => {
          console.log(error);
        });
  }

  signinUser(email: string, senha: string) {
    firebase.auth().signInWithEmailAndPassword(email, senha)
      .then(
        response => {
          this.router.navigate(['/']);
          firebase.auth().currentUser.getIdToken()
            .then(
              (token: string) => { this.token = token; }
            );
        }
      )
      .catch(
        error => {
          console.log(error);
        });
  }

  logout() {
    firebase.auth().signOut();
    this.token = null;
  }

  getToken() {
    firebase.auth().currentUser.getIdToken()
      .then(
      (token: string) => { this.token = token; }
      );
    return this.token;
  }

  isAuthenticated() {
    return this.token != null;
  }
}
