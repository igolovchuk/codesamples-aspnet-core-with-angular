import { TEntity } from 'src/app/modules/core/models/entity/entity';
import { State } from './state';
import { ActionType } from './action-type';

export class CoreAngularDemoion extends TEntity<CoreAngularDemoion> {
  fromState: State;
  toState: State;
  actionType: ActionType;
  isFixed: boolean;

  constructor(CoreAngularDemoion: Partial<CoreAngularDemoion>) {
    super(CoreAngularDemoion);
    this.fromState = new State(this.fromState);
    this.toState = new State(this.toState);
    this.actionType = new ActionType(this.actionType);
    this.isFixed = !!this.isFixed;
  }
}
