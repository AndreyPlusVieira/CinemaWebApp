export interface ResponseSession {
  value: Session[];
  statusCode: number;
  contentType?: any;
}

export interface ResponseSessionById {
  value: Session;
  statusCode: number;
  contentType?: any;
}

export interface ResponseSessionUpdate {
  value: any;
  statusCode: number;
  contentType?: any;
}

export interface Session {
  id: number;
  startTime: Date;
  endTIme: Date;
  entryValue: number;
  animationType: string;
  audioType: string;
  roomsId: number;
  movieId: number;
}

export interface RequestSession {
  id: number;
  startTime: Date;
  endTIme: Date;
  entryValue: number;
  animationType: string;
  audioType: string;
  roomsId: number;
  movieId: number;
}
