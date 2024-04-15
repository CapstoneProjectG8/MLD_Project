/** user's role */
export type Role = 'Admin' | 'Teacher' | 'Leader' | 'Principle';

export interface LoginParams {
  username: string;
  password: string;
}

export interface LoginResult {
  /** auth token */
  token: string;
  username: string;
  role: Role;
}

export interface LogoutParams {
  token: string;
}

export interface LogoutResult {}
