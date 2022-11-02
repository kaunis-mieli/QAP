/**
 * This is a TypeGen auto-generated file.
 * Any changes made to this file can be lost when this file is regenerated.
 */

import { QAPRequest } from "./qap-request";
import { IQAPRequest } from "./iqap-request";

export interface RegisterRequestDTO extends QAPRequest {
    alias: string;
    password: string;
    email: string;
    fullName: string;
}
