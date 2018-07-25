import { IEmployee } from 'src/helpers/employee';
import { IOrder } from 'src/helpers/order';

export interface PostEmployeeResult extends IEmployee {
    Headers: string[];
}
