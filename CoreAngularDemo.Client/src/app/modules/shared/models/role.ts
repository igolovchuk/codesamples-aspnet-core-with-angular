import { TEntity } from '../../core/models/entity/entity';

export class Role extends TEntity<Role> {
  name: string;
  transName: string;

  constructor(role: Partial<Role>) {
    super(role);
  }
}
