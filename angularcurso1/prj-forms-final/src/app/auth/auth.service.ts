// import { map, catchError } from 'rxjs/operators';
import * as firebase from 'firebase';

export class AuthService {
  token: string;

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

  getToken() {
    firebase.auth().currentUser.getIdToken()
      .then(
      (token: string) => { this.token = token; }
      );
  }
}
