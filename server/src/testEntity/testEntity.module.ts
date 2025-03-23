import { Module, forwardRef } from "@nestjs/common";
import { AuthModule } from "../auth/auth.module";
import { TestEntityModuleBase } from "./base/testEntity.module.base";
import { TestEntityService } from "./testEntity.service";
import { TestEntityController } from "./testEntity.controller";
import { TestEntityResolver } from "./testEntity.resolver";

@Module({
  imports: [TestEntityModuleBase, forwardRef(() => AuthModule)],
  controllers: [TestEntityController],
  providers: [TestEntityService, TestEntityResolver],
  exports: [TestEntityService],
})
export class TestEntityModule {}
