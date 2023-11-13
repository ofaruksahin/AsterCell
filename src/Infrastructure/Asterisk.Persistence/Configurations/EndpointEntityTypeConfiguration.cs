using Asterisk.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Asterisk.Persistence.Configurations
{
    public class EndpointEntityTypeConfiguration : IEntityTypeConfiguration<Endpoint>
    {
        public void Configure(EntityTypeBuilder<Endpoint> builder)
        {
            builder.HasKey(f => f.Id);

            builder
                .Property(f => f.Id)
                .HasColumnType("varchar")
                .HasColumnName("id")
                .HasMaxLength(40)
                .IsRequired();

            builder
                .Property(f => f.Aors)
                .HasColumnType("varchar")
                .HasColumnName("aors")
                .HasMaxLength(200)
                .IsRequired();

            builder
                .Property(f => f.Auth)
                .HasColumnType("varchar")
                .HasColumnName("auth")
                .HasMaxLength(40)
                .IsRequired();

            builder
                .Property(f => f.Context)
                .HasColumnType("varchar")
                .HasColumnName("context")
                .HasMaxLength(40)
                .IsRequired();

            builder
                .Property(f => f.Disallow)
                .HasColumnType("varchar")
                .HasColumnName("disallow")
                .HasMaxLength(200)
                .IsRequired();

            builder
                .Property(f => f.Allow)
                .HasColumnType("varchar")
                .HasColumnName("allow")
                .HasMaxLength(200)
                .IsRequired();

            builder
                .Property(f => f.IceSupport)
                .HasColumnType("varchar")
                .HasColumnName("ice_support")
                .HasMaxLength(3);

            builder
                .Property(f => f.UseAvpf)
                .HasColumnType("varchar")
                .HasColumnName("use_avpf")
                .HasMaxLength(3);

            builder
                .Property(f => f.MediaEncryption)
                .HasColumnType("varchar")
                .HasColumnName("media_encryption")
                .HasMaxLength(4);

            builder
                .Property(f => f.DtlsVerify)
                .HasColumnType("varchar")
                .HasColumnName("dtls_verify")
                .HasMaxLength(40)
                .IsRequired();

            builder
                .Property(f => f.DtlsCertFile)
                .HasColumnType("varchar")
                .HasColumnName("dtls_cert_file")
                .HasMaxLength(200)
                .IsRequired();

            builder
                .Property(f => f.DtlsCaFile)
                .HasColumnType("varchar")
                .HasColumnName("dtls_ca_file")
                .HasMaxLength(200)
                .IsRequired();

            builder
                .Property(f => f.DtlsSetup)
                .HasColumnType("varchar")
                .HasColumnName("dtls_setup")
                .HasMaxLength(7)
                .IsRequired();

            builder
                .Property(f => f.MediaUseReceivedTransport)
                .HasColumnType("varchar")
                .HasColumnName("media_use_received_transport")
                .HasMaxLength(3)
                .IsRequired();

            builder
                .Property(f => f.RtcpMux)
                .HasColumnType("varchar")
                .HasColumnName("rtcp_mux")
                .HasMaxLength(3)
                .IsRequired();

            builder.ToTable("ps_endpoints");
        }
    }
}
