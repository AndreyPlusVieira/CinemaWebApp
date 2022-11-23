export interface ResponseRooms {
  value: Room[];
  statusCode: number;
  contentType?: any;
}

export interface Room {
  id: number;
  name: string;
  seats: number;
}
