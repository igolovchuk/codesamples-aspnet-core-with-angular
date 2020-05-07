import { TEntity } from '../../core/models/entity/entity';

export class VehicleType extends TEntity<VehicleType> {
  name: string;

  constructor(vehicleType: Partial<VehicleType>) {
    super(vehicleType);
  }
}
