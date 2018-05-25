
export class CounterService {
    counter: number = 0;

    setCounter(){
        this.counter++;
        console.log(this.counter);
    }



}