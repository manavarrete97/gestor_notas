using gestor_notas.DTO;
using gestor_notas.Manager;
using gestor_notas.DAO.Interface;
using gestor_notas.Common.Interface;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using Npgsql;

namespace gestor_notas_test
{
 [TestFixture]
 public class UpdateProfesorManagerTests
 {
 private Mock<IPostgresConnection> _postgresConnectionMock;
 private Mock<IUpdateProfesorDAO> _updateProfesorDAOMock;
 private UpdateProfesorManager _updateProfesorManager;
 private NpgsqlConnection _realConnection;

 [SetUp]
 public void Setup()
 {
 _postgresConnectionMock = new Mock<IPostgresConnection>();
 _updateProfesorDAOMock = new Mock<IUpdateProfesorDAO>();
 _updateProfesorManager = new UpdateProfesorManager(_postgresConnectionMock.Object, _updateProfesorDAOMock.Object);
 _realConnection = new NpgsqlConnection(); // Replace with a valid connection string for testing
 }

 [TearDown]
 public void TearDown()
 {
 _realConnection.Dispose();
 }

 [Test]
 public async Task UpdateProfesorAsync_ShouldReturnTrue_WhenDAOOperationSucceeds()
 {
 // Arrange
 var profesorDTO = new ProfesorDTO { Id =1, Nombre = "Juan Pérez" };
 _postgresConnectionMock.Setup(p => p.GetConnection()).Returns(_realConnection);
 _updateProfesorDAOMock.Setup(p => p.UpdateProfesorAsync(It.IsAny<NpgsqlConnection>(), profesorDTO)).ReturnsAsync(true);

 // Act
 var result = await _updateProfesorManager.UpdateProfesorAsync(profesorDTO);

 // Assert
 Assert.That(result, Is.True);
 }

 [Test]
 public async Task UpdateProfesorAsync_ShouldReturnFalse_WhenDAOOperationFails()
 {
 // Arrange
 var profesorDTO = new ProfesorDTO { Id =1, Nombre = "Juan Pérez" };
 _postgresConnectionMock.Setup(p => p.GetConnection()).Returns(_realConnection);
 _updateProfesorDAOMock.Setup(p => p.UpdateProfesorAsync(It.IsAny<NpgsqlConnection>(), profesorDTO)).ReturnsAsync(false);

 // Act
 var result = await _updateProfesorManager.UpdateProfesorAsync(profesorDTO);

 // Assert
 Assert.That(result, Is.False);
 }
 }
}