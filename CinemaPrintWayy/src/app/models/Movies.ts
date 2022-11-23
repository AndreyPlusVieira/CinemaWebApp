export interface ResponseMovies {
  value: Movie[];
  statusCode: number;
  contentType?: any;
}

export interface ResponseMoviesUpdate {
  value: any;
  statusCode: number;
  contentType?: any;
}

export interface ResponseMoviesById {
  value: Movie;
  statusCode: number;
  contentType?: any;
}

export interface Movie {
  id: number;
  title: string;
  description: string;
  image: string;
  duration: number;
  active: boolean;
}

export interface ResponseById {
  value: Movie;
}

export interface RequestMovie {
  id: number;
  title: string;
  description: string;
  image: string;
  duration: number;
  active: boolean;
}

export interface Value {
  statusCode: number;
  id: number;
  title: string;
  description: string;
  image: string;
  duration: number;
  active: boolean;
  sessions: any[];
  notifications: any[];
  isValid: boolean;
}
